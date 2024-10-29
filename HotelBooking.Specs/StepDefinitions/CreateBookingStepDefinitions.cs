using Reqnroll;
using System;
using System.Collections.Generic;
using System.Linq;
using HotelBooking.Core;
using Moq;
using NUnit.Framework.Legacy;

namespace HotelBooking.Specs.StepDefinitions
{
    [Binding]
    public class CreateBookingStepDefinitions
    {
        private Mock<IRepository<Booking>> mockBookingRepo = new();
        private Mock<IRepository<Room>> mockRoomRepo = new();
        private IBookingManager bookingManager;
        private Booking booking = new();
        private bool bookingResult;
        private DateTime startDate;
        private DateTime endDate;

        public CreateBookingStepDefinitions()
        {
            bookingManager = new BookingManager(mockBookingRepo.Object, mockRoomRepo.Object);
        }

        [Given(@"the start date is (.*)/(.*)/(.*)")]
        public void GivenTheStartDateIs(int day, int month, int year)
        {
            startDate = new DateTime(year, month, day);
            booking.StartDate = startDate;
        }

        [Given(@"the end date is (.*)/(.*)/(.*)")]
        public void GivenTheEndDateIs(int day, int month, int year)
        {
            endDate = new DateTime(year, month, day);
            booking.EndDate = endDate;
        }
        
        [Given(@"the room is available")]
        public void GivenTheRoomIsAvailable()
        {
            // Mock get all function, to return the room we are attempting to book later on.
            mockRoomRepo.Setup(repo => repo.GetAll()).Returns(new List<Room>
            {
                new() { Id = 1, Description = "Standard Room" },
                new() { Id = 2, Description = "Deluxe Room" }
            }.AsQueryable());
        }

        [Given(@"the room is already booked")]
        public void GivenTheRoomIsAlreadyBooked()
        {
            mockBookingRepo.Setup(repo => repo.Get(It.IsAny<int>())).Returns(new Booking
            {
                StartDate = startDate,
                EndDate = endDate,
                RoomId = 1
            });
        }

        [Given(@"the room is not already booked")]
        public void GivenTheRoomIsNotAlreadyBooked()
        {
            mockBookingRepo.Setup(repo => repo.Get(It.IsAny<int>())).Returns((Booking)null);
        }

        [Given(@"the booking is in the future")]
        public void GivenTheBookingIsInTheFuture()
        {
            // Assuming start date is already in the future; no change needed.
        }

        [Given(@"the booking is not in the future")]
        public void GivenTheBookingIsNotInTheFuture()
        {
            startDate = startDate.AddDays(-2);
            endDate = endDate.AddDays(-1);
        }

        [When(@"a customer attempts to book the room")]
        public void WhenACustomerAttemptsToBookTheRoom()
        {
            booking = new Booking
            {
                StartDate = startDate,
                EndDate = endDate,
                RoomId = 1,
                CustomerId = 1,
                IsActive = true
            };

            try
            {
                bookingResult = bookingManager.CreateBooking(booking);
            }
            catch (Exception ex)
            {
                // No need to save exception, as createBooking returns a bool
            }
        }

        [Then(@"the booking should be valid")]
        public void ThenTheBookingShouldBeValid()
        {
            ClassicAssert.IsTrue(bookingResult);
        }

        [Then(@"the booking should be invalid")]
        public void ThenTheBookingShouldBeInvalid()
        {
            ClassicAssert.IsFalse(bookingResult);
        }
    }
}
