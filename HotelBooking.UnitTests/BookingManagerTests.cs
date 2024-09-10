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

        public BookingManagerTests()
        {
            start = DateTime.Today.AddDays(10);
            end = DateTime.Today.AddDays(20);
            bookingRepository = new FakeBookingRepository(start, end);
            roomRepository = new FakeRoomRepository();
            bookingManager = new BookingManager(bookingRepository, roomRepository);
        }

        [Fact]
        public void FindAvailableRoom_StartDateNotInTheFuture_ThrowsArgumentException()
        {
            // Arrange
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
            Booking booking = bookingRepository.Get(1);

            // Act
            bookingManager.CreateBooking(booking);
            bool UnsuccessfulBooking = bookingManager.CreateBooking(booking);

            // Assert
            Assert.False(UnsuccessfulBooking);
        }

        [Fact]
        public void GetFullyOccupiedDates_StartDateBiggerThanEndDate_ThrowsException()
        {
            //Arrange
            var startDate = DateTime.Today.AddDays(3);
            var endDate = DateTime.Today.AddDays(2);

            //Act + Assert
            Assert.Throws<ArgumentException>( () => bookingManager.GetFullyOccupiedDates(startDate, endDate));

        }

        [Fact]
        public void GetFullyOccupiedDates_OccupiedDates_ReturnsNonEmptyList()
        {
            //Arrange


            //Act
            var result = bookingManager.GetFullyOccupiedDates(start, end);

            //Assert
            Assert.NotEmpty(result);
        }

        [Fact]
        public void GetFullyOccupiedDates_UnocupiedDates_ReturnsEmptyList()
        {
            //Arrange
            var startDate = DateTime.Today.AddDays(1);
            var endDate = DateTime.Today.AddDays(2);

            //Act
            var result = bookingManager.GetFullyOccupiedDates(startDate, endDate);

            //Assert
            Assert.Empty(result);
        }
    }
}
