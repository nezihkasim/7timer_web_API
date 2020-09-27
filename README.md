# 7timer_web_API
7timer.infoWeb API to retrieve the weather information for a given latitude and longitude point

The Web API has the following URL:

http://www.7timer.info/bin/astro.php?lon=LON&lat=LAT&ac=0&unit=metric&output=json&tzshift=0

Where LON and LAT are the input coordinates.

The program handles the followings:

- Takes latitude and longitude information from the user
- Makes a request to the API with those coordinates, and gets the response
- Parses (deserialize) the incoming JSON data, and displays the weather information
