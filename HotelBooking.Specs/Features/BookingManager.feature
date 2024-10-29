Feature: Create Booking

A hotel booking system allows customers to book a room in a hotel.
The system ensures that dates are valid and that the room is available.

    @BookingTests
    Scenario: Attempt to book a room with overlapping dates in the future
        Given the start date is 30/10/2024
        And the end date is 31/10/2024
        And the room is already booked
        And the booking is in the future
        When a customer attempts to book the room
        Then the booking should be invalid

    Scenario: Attempt to book a room with an end date before the start date
        Given the start date is 31/10/2024
        And the end date is 30/10/2024
        And the room is not already booked
        And the booking is in the future
        When a customer attempts to book the room
        Then the booking should be invalid

    Scenario: Attempt to book a room with dates in the past
        Given the start date is 28/10/2024
        And the end date is 29/10/2024
        And the room is not already booked
        And the booking is not in the future
        When a customer attempts to book the room
        Then the booking should be invalid

    Scenario: Successfully book a room with valid future dates and availability
        Given the start date is 30/10/2024
        And the end date is 31/10/2024
        And the room is available
        And the room is not already booked
        And the booking is in the future
        When a customer attempts to book the room
        Then the booking should be valid