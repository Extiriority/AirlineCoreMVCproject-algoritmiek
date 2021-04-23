CREATE TABLE flights
(
    id                  SERIAL PRIMARY KEY,
    aircraft_type       TEXT NOT NULL,
    departure_country   TEXT NOT NULL,
    arrival_country     TEXT NOT NULL,
    departure_time      DATETIME,
    arrival_time        DATETIME,
    flight_status       BIT 
);