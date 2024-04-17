# Parking System

This console-based parking system is built using .NET 5. It allows for the management of parking lots where each lot can accommodate either 1 car or 1 motorcycle. Each person is allocated a quota of 1 lot. The system keeps track of the total number of lots available at each location.

## Features

### Check-In
- `park <license_plate> <color> <vehicle_type>`: Parks a vehicle with the given license plate, color, and type (Car or Motorcycle).
- `create_parking_lot <number_of_slots>`: Creates a parking lot with the specified number of slots.
  
### Check-Out
- `leave <slot_number>`: Removes a vehicle from the specified slot, making it available for use by another vehicle.

### Reports
- `status`: Displays the current status of the parking lot, including slot numbers, vehicle types, license plates, and colors.
- `type_of_vehicles <vehicle_type>`: Displays the number of vehicles of the specified type (Mobil or Motor).
- `registration_numbers_for_vehicles_with_ood_plate`: Displays the registration numbers of vehicles with odd-numbered license plates.
- `registration_numbers_for_vehicles_with_event_plate`: Displays the registration numbers of vehicles with even-numbered license plates.
- `registration_numbers_for_vehicles_with_colour <color>`: Displays the registration numbers of vehicles with the specified color.
- `slot_numbers_for_vehicles_with_colour <color>`: Displays the slot numbers of vehicles with the specified color.
- `slot_number_for_registration_number <license_plate>`: Displays the slot number of the vehicle with the specified license plate.

## Usage Example

Assuming there are 6 available lots, the following commands illustrate how to use the system:

```bash
$ create_parking_lot 6
$ park B-1234-XYZ Putih Mobil
$ park B-9999-XYZ Putih Motor
$ leave 2
$ status
```

Thanks for checking out my parking system! If you have any questions or feedback, please don't hesitate to reach out.
