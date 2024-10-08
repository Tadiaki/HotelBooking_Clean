using System;
using System.Collections.Generic;
using NUnit.Framework;
using TechTalk.SpecFlow;
using Moq;
using HotelBooking.Core;


[Binding]
public class HotelBookingSteps
{
    private Mock<IRepository<Booking>> mockBookingRepo;
    private Mock<IRepository<Room>> mockRoomRepo;
    private BookingManager bookingManager;
    private bool bookingResult;
    private string failureMessage;

    [Before]
    public void Setup()
    {
        mockBookingRepo = new Mock<IRepository<Booking>>();
        mockRoomRepo = new Mock<IRepository<Room>>();
        bookingManager = new BookingManager(mockBookingRepo.Object, mockRoomRepo.Object);
    }


    [Given(@"a hotel room is available from ""(.*)"" to ""(.*)""")]
    public void GivenAHotelRoomIsAvailableFromTo(string p0, string p1)
    {

        var existingBooking = new Booking
        {
            RoomId = 1,
            StartDate = DateTime.Parse(p0),
            EndDate = DateTime.Parse(p1),
            IsActive = true
        };
        mockBookingRepo.Setup(b => b.GetAll()).Returns(new List<Booking> { existingBooking });
        mockRoomRepo.Setup(r => r.GetAll()).Returns(new List<Room> { new Room { Id = 1 } });
    }

    [When(@"I book the hotel room from ""(.*)"" to ""(.*)""")]
    public void WhenIBookTheHotelRoom(string bookingStartDate, string bookingEndDate)
    {
        var booking = new Booking
        {
            StartDate = DateTime.Parse(bookingStartDate),
            EndDate = DateTime.Parse(bookingEndDate),
            IsActive = true
        };

        try
        {
            bookingResult = bookingManager.CreateBooking(booking);
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
        var booking = new Booking
        {
            StartDate = DateTime.Parse(bookingStartDate),
            EndDate = DateTime.Parse(bookingEndDate),
            IsActive = true
        };

        try
        {
            bookingResult = bookingManager.CreateBooking(booking);
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
        
        Assert.Equals(bookingResult,true);
    }
    /**
    [Then(@"the booking should fail with a message ""(.*)""")]
    public void ThenTheBookingShouldFailWithMessage(string expectedMessage)
    {
        Assert.Equals(bookingResult, false);
        Assert.Equals(expectedMessage, failureMessage);
    }*/
}
