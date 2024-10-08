using HotelBooking.Core;
using System;
using Xunit;

namespace HotelBookingTests
{
    [Binding]
    public class BookingSteps
    {
        private IBookingManager bookingManager;
        private bool bookingResult;
        private string failureMessage;

        [Given(@"a hotel room is available from ""(.*)"" to ""(.*)""")]
        public void GivenAHotelRoomIsAvailable(string startDate, string endDate)
        {
           
            bookingManager.SetRoomAvailability(DateTime.Parse(startDate), DateTime.Parse(endDate));
        }

        [Given(@"a hotel room is booked from ""(.*)"" to ""(.*)""")]
        public void GivenAHotelRoomIsBooked(string startDate, string endDate)
        {

            bookingManager.BookRoom(DateTime.Parse(startDate), DateTime.Parse(endDate));
        }

        [When(@"I book the hotel room from ""(.*)"" to ""(.*)""")]
        public void WhenIBookTheHotelRoom(string bookingStartDate, string bookingEndDate)
        {
            try
            {
                bookingResult = bookingManager.BookRoom(DateTime.Parse(bookingStartDate), DateTime.Parse(bookingEndDate));
            }
            catch (Exception e)
            {
                bookingResult = false;
                failureMessage = e.Message;
            }
        }

        [When(@"I try to book the hotel room from ""(.*)"" to ""(.*)""")]
        public void WhenITryToBookTheHotelRoom(string bookingStartDate, string bookingEndDate)
        {
            try
            {
                bookingResult = bookingManager.BookRoom(DateTime.Parse(bookingStartDate), DateTime.Parse(bookingEndDate));
            }
            catch (Exception e)
            {
                bookingResult = false;
                failureMessage = e.Message;
            }
        }

        [Then(@"the booking should be successful")]
        public void ThenTheBookingShouldBeSuccessful()
        {
            Assert.IsTrue(bookingResult, "Booking should succeed");
        }

        [Then(@"the booking should fail with a message ""(.*)""")]
        public void ThenTheBookingShouldFailWithMessage(string expectedMessage)
        {
            Assert.IsFalse(bookingResult, "Booking should fail");
            Assert.IsTrue(failureMessage.Contains(expectedMessage), $"Expected message: {expectedMessage}, but got: {failureMessage}");
        }
    }
}
