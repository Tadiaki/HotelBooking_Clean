using System;
using System.Collections.Generic;
using NUnit.Framework;
using TechTalk.SpecFlow;
using Moq;
using HotelBooking.Core;


[Binding]
public class HotelBookingSteps
{
    private Mock<IRepository<Booking>> mockBookingRepo = new Mock<IRepository<Booking>>();
    private Mock<IRepository<Room>> mockRoomRepo = new Mock<IRepository<Room>>();
    // private BookingManager bookingManager;
    private IBookingManager bookingManager;

    public HotelBookingSteps()
    {
        bookingManager = new BookingManager(mockBookingRepo.Object, mockRoomRepo.Object);
    }

    

    private bool bookingResult;
    private string failureMessage;

    // [Before]
    // public void Setup()
    // {
    //     mockBookingRepo = new Mock<IRepository<Booking>>();
    //     mockRoomRepo = new Mock<IRepository<Room>>();
    //     bookingManager = new BookingManager(mockBookingRepo.Object, mockRoomRepo.Object);
    // }


    // [Given(@"a hotel room is available from ""(.*)"" to ""(.*)""")]
    // public void GivenAHotelRoomIsAvailableFromTo(string p0, string p1)
    // {

    //     var existingBooking = new Booking
    //     {
    //         RoomId = 1,
    //         StartDate = DateTime.Parse(p0),
    //         EndDate = DateTime.Parse(p1),
    //         IsActive = true
    //     };
    //     mockBookingRepo.Setup(b => b.GetAll()).Returns(new List<Booking> { existingBooking });
    //     mockRoomRepo.Setup(r => r.GetAll()).Returns(new List<Room> { new Room { Id = 1 } });
    // }

    // [When(@"I book the hotel room from ""(.*)"" to ""(.*)""")]
    // public void WhenIBookTheHotelRoom(string bookingStartDate, string bookingEndDate)
    // {
    //     var booking = new Booking
    //     {
    //         StartDate = DateTime.Parse(bookingStartDate),
    //         EndDate = DateTime.Parse(bookingEndDate),
    //         IsActive = true
    //     };

    //     try
    //     {
    //         bookingResult = bookingManager.CreateBooking(booking);
    //     }
    //     catch (Exception e)
    //     {
    //         bookingResult = false;
    //         failureMessage = e.Message;
    //     }
    // }

    // [When(@"I try to book the hotel room from ""(.*)"" to ""(.*)""")]
    // public void WhenITryToBookTheHotelRoom(string bookingStartDate, string bookingEndDate)
    // {
    //     var booking = new Booking
    //     {
    //         StartDate = DateTime.Parse(bookingStartDate),
    //         EndDate = DateTime.Parse(bookingEndDate),
    //         IsActive = true
    //     };

    //     try
    //     {
    //         bookingResult = bookingManager.CreateBooking(booking);
    //     }
    //     catch (Exception e)
    //     {
    //         bookingResult = false;
    //         failureMessage = e.Message;
    //     }
    // }

    // [Then(@"the booking should be successful")]
    // public void ThenTheBookingShouldBeSuccessful()
    // {
        
    //     Assert.Equals(bookingResult,true);
    // }
    // /**
    // [Then(@"the booking should fail with a message ""(.*)""")]
    // public void ThenTheBookingShouldFailWithMessage(string expectedMessage)
    // {
    //     Assert.Equals(bookingResult, false);
    //     Assert.Equals(expectedMessage, failureMessage);
    // }*/


[Given(@"the start date is (.*)/(.*)/(.*)")]
public void Giventhestartdateis(int args1)
{
	bookingManager();
}

[Given(@"the end date is (.*)/(.*)/(.*)")]
public void Giventheenddateis(int args1)
{
	_scenarioContext.Pending();
}

[Given(@"the room is already booked")]
public void Giventheroomisalreadybooked()
{
	_scenarioContext.Pending();
}

[Given(@"the booking is in the future")]
public void Giventhebookingisinthefuture()
{
	_scenarioContext.Pending();
}

[When(@"a customer attempts to book the room")]
public void Whenacustomerattemptstobooktheroom()
{
	_scenarioContext.Pending();
}

[Then(@"the booking should be invalid")]
public void Thenthebookingshouldbeinvalid()
{
	_scenarioContext.Pending();
}

[Given(@"the start date is (.*)/(.*)/(.*)")]
public void Giventhestartdateis(int args1)
{
	_scenarioContext.Pending();
}

[Given(@"the end date is (.*)/(.*)/(.*)")]
public void Giventheenddateis(int args1)
{
	_scenarioContext.Pending();
}

[Given(@"the room is not already booked")]
public void Giventheroomisnotalreadybooked()
{
	_scenarioContext.Pending();
}

[Given(@"the booking is in the future")]
public void Giventhebookingisinthefuture()
{
	_scenarioContext.Pending();
}

[When(@"a customer attempts to book the room")]
public void Whenacustomerattemptstobooktheroom()
{
	_scenarioContext.Pending();
}

[Then(@"the booking should be invalid")]
public void Thenthebookingshouldbeinvalid()
{
	_scenarioContext.Pending();
}

[Given(@"the start date is (.*)/(.*)/(.*)")]
public void Giventhestartdateis(int args1)
{
	_scenarioContext.Pending();
}

[Given(@"the end date is (.*)/(.*)/(.*)")]
public void Giventheenddateis(int args1)
{
	_scenarioContext.Pending();
}

[Given(@"the room is not already booked")]
public void Giventheroomisnotalreadybooked()
{
	_scenarioContext.Pending();
}

[Given(@"the booking is not in the future")]
public void Giventhebookingisnotinthefuture()
{
	_scenarioContext.Pending();
}

[When(@"a customer attempts to book the room")]
public void Whenacustomerattemptstobooktheroom()
{
	_scenarioContext.Pending();
}

[Then(@"the booking should be invalid")]
public void Thenthebookingshouldbeinvalid()
{
	_scenarioContext.Pending();
}

[Given(@"the start date is (.*)/(.*)/(.*)")]
public void Giventhestartdateis(int args1)
{
	_scenarioContext.Pending();
}

[Given(@"the end date is (.*)/(.*)/(.*)")]
public void Giventheenddateis(int args1)
{
	_scenarioContext.Pending();
}

[Given(@"the room is not already booked")]
public void Giventheroomisnotalreadybooked()
{
	_scenarioContext.Pending();
}

[Given(@"the booking is in the future")]
public void Giventhebookingisinthefuture()
{
	_scenarioContext.Pending();
}

[When(@"a customer attempts to book the room")]
public void Whenacustomerattemptstobooktheroom()
{
	_scenarioContext.Pending();
}

[Then(@"the booking should be valid")]
public void Thenthebookingshouldbevalid()
{
	_scenarioContext.Pending();
}


    
}
