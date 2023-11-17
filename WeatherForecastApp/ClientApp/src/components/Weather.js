import React, { useState, useEffect } from "react";
import axios from "axios";

function Weather() {
  const [weatherData, setWeatherData] = useState([]);
  const [isLoading, setIsLoading] = useState(true);

  useEffect(() => {
    axios.get("weather/getweatherforecast").then((response) => {
      setWeatherData(response.data);
      setIsLoading(false);
    });
  }, []);

  if (isLoading) {
    return <p>Loading...</p>;
  }

  return (
    <table className="table">
      <thead>
        <tr>
          <th>Weather State Name</th>
          <th>Image</th>
          <th>Date Updated</th>
          <th>Applicable Date</th>
          <th>Min Temp</th>
          <th>Max Temp</th>
          <th>Current Temp</th>
          <th>Wind Speed</th>
          <th>Humidity</th>
        </tr>
      </thead>
      <tbody>
        {weatherData.map((item) => (
          <tr key={item.id}>
            <td>{item.weatherStateName}</td>
            <td>
              <img src={item.imageUrl} alt={item.weatherStateName} />
            </td>
            <td>{item.dateUpdated}</td>
            <td>{item.applicableDate}</td>
            <td>{item.minTemp}</td>
            <td>{item.maxTemp}</td>
            <td>{item.currentTemp}</td>
            <td>{item.windSpeed}</td>
            <td>{item.humidity}</td>
          </tr>
        ))}
      </tbody>
    </table>
  );
}

export default Weather;
