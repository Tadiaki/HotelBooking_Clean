Feature: Hotel Room Booking

As a user
I want to be able to book a hotel room for a specific period
So that I can reserve a room if it is available during that time


Scenario: Successfully book a hotel room when available
	Given a hotel room is available from "2024-11-01" to "2024-11-30"
	When I book the hotel room from "2024-11-10" to "2024-11-15"
	Then the booking should be successful

