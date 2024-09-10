using System;
using HotelBooking.Core;
using HotelBooking.UnitTests.Fakes;
using Xunit;
using System.Linq;
using HotelBooking.Infrastructure.Repositories;


namespace HotelBooking.UnitTests
{
    public class BookingManagerTests
    {
        private IBookingManager bookingManager;
        IRepository<Booking> bookingRepository;
        DateTime start;
        DateTime end;
        IRepository<Room> roomRepository;

        private void ResetVariables()
        {
            bookingRepository = new FakeBookingRepository(start, end);
            roomRepository = new FakeRoomRepository();
            bookingManager = new BookingManager(bookingRepository, roomRepository);
        }

        public BookingManagerTests()
        {
            start = DateTime.Today.AddDays(10);
            end = DateTime.Today.AddDays(20);
        }

        [Fact]
        public void FindAvailableRoom_StartDateNotInTheFuture_ThrowsArgumentException()
        {
            // Arrange
            ResetVariables();
            DateTime date = DateTime.Today;

            // Act
            Action act = () => bookingManager.FindAvailableRoom(date, date);

            // Assert
            Assert.Throws<ArgumentException>(act);
        }

        [Fact]
        public void FindAvailableRoom_RoomAvailable_RoomIdNotMinusOne()
        {
            // Arrange
            ResetVariables();
            DateTime date = DateTime.Today.AddDays(1);
            // Act
            int roomId = bookingManager.FindAvailableRoom(date, date);
            // Assert
            Assert.NotEqual(-1, roomId);
        }

        [Fact]
        public void FindAvailableRoom_RoomAvailable_ReturnsAvailableRoom()
        {
            // This test was added to satisfy the following test design
            // principle: "Tests should have strong assertions".

            // Arrange
            ResetVariables();
            DateTime date = DateTime.Today.AddDays(1);

            // Act
            int roomId = bookingManager.FindAvailableRoom(date, date);

            var bookingForReturnedRoomId = bookingRepository.GetAll().Where(
                b => b.RoomId == roomId
                && b.StartDate <= date
                && b.EndDate >= date
                && b.IsActive);

            // Assert
            Assert.Empty(bookingForReturnedRoomId);
        }

        [Fact]
        public void CreateBooking_BookingAvailable_ReturnsTrue()
        {
            // Arrange
            ResetVariables();
            Booking booking = bookingRepository.Get(2);
            booking.StartDate = booking.StartDate.AddDays(20);
            booking.EndDate = booking.EndDate.AddDays(30);

            // Act
            bool bookingResult = bookingManager.CreateBooking(booking);

            // Assert
            Assert.True(bookingResult);
        }


        [Fact]
        public void CreateBooking_BookingAvailable_BookingIdIsSameAsInput()
        {
            // Arrange
            ResetVariables();
            Booking booking = bookingRepository.Get(2);

            // Act
            bookingManager.CreateBooking(booking);

            // Assert
            Assert.Equal(2, booking.Id);
        }


        [Fact]
        public void CreateBooking_StartDateIsLaterThanEndDate_ReturnsFalse()
        {
            // Arrange
            ResetVariables();
            Booking booking = bookingRepository.Get(1);
            booking.StartDate.AddDays(20);

            // Act
            bool bookingResult = bookingManager.CreateBooking(booking);

            // Assert
            Assert.False(bookingResult);
        }

        [Fact]
        public void CreateBooking_DuplicateRoomBooking_ReturnsFalse()
        {
            // Arrange
            ResetVariables();
            Booking booking = bookingRepository.Get(1);

            // Act
            bookingManager.CreateBooking(booking);
            bool UnsuccessfulBooking = bookingManager.CreateBooking(booking);

            // Assert
            Assert.False(UnsuccessfulBooking);
        }



    }
}
