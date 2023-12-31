﻿using Core.Models;
using Infrastructure.Interfaces;
using System;
using System.Linq;
namespace Infrastructure.Data
{
    public class BookingRepository : IBookingRepository
    {
        private readonly ApplicationDbContext _context;
        public BookingRepository(ApplicationDbContext context, IUserLoginService userLoginService)
        {
            _context = context;
        }

        public bool CancelBooking(int bookingId, string patientId)
        {
            var booking = _context.Bookings.Where(b => b.PatientId == patientId && b.Id == bookingId).FirstOrDefault();

            if (booking != null && booking.Status != BookingStatus.PENDING)
            {
                booking.Status = BookingStatus.CANCELLED;
                _context.SaveChanges();
                return true;
            }

            return false;
        }

        public bool MakeBooking(BookingPayload obj, string patientId)
        {
            var appointmentInfo = _context.Appointments
            .Where(appointment => appointment.TimeSlotId == obj.TimeSlotId)
            .Select(appointment => new { appointment.DoctorId, appointment.Price})
            .FirstOrDefault();

            float bookingPrice = appointmentInfo.Price;
            float finalBookingPrice = bookingPrice;

            var couponInfo = _context.Coupons.FirstOrDefault(c => c.DiscountCode.Equals(obj.CouponId));

            if(couponInfo != null && couponInfo.DiscountCodeStatus != DiscountCodeStatus.DEACTIVATED && couponInfo.CurrentRequestsNumber > 0) 
            {
                if(couponInfo.DiscountType == DiscountType.PERCENTAGE)
                {
                    double percentage = couponInfo.DiscountValue / 100.00;
                    var result = appointmentInfo.Price * percentage;
                    bookingPrice = (float)(appointmentInfo.Price - result);
                }
                else
                {
                    bookingPrice = appointmentInfo.Price - couponInfo.DiscountValue;
                }

                couponInfo.CurrentRequestsNumber--;
            }

            var booking = new Booking
            {
                DoctorId = appointmentInfo.DoctorId,
                TimeSlotId = obj.TimeSlotId,
                PatientId = patientId,
                BookingPrice = appointmentInfo.Price,
                FinalBookingPrice = bookingPrice,
                CreatedAt = DateTime.Now
            };

            _context.Bookings.Add(booking);
            _context.SaveChanges();

            return true;
        }
    }
}
