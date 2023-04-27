console.log('test');

let statistics = document.getElementById('statistics');
let hourly = document.getElementById('hourly');
let about = document.getElementById('about');

let statisticsText = document.getElementById('statisticsText');
let hourlyText = document.getElementById('hourlyText');
let aboutText = document.getElementById('aboutText');

let active = document.querySelector('.active');

if (!active) {
    active = statistics;
    active.classList.add('active');
  }

statistics.addEventListener('click', function(){
    statistics.style.display = statisticsText;
    hourly.style.display = 'block';
    about.style.display = 'block';

    statisticsText.style.display = 'block';
    hourlyText.style.display = 'none';
    aboutText.style.display = 'none';

    active.classList.remove('active');
    active = statistics;
    active.classList.add('active');
})

hourly.addEventListener('click', function(){
    hourly.style.display = 'block';
    statistics.style.display = hourlyText;
    about.style.display = 'block';

    statisticsText.style.display = 'none';
    hourlyText.style.display = 'block';
    aboutText.style.display = 'none';

    active.classList.remove('active');
    active = hourly;
    active.classList.add('active');
})

about.addEventListener('click', function(){
    about.style.display = 'block';
    hourly.style.display = 'block';
    statistics.style.display = aboutText;

    statisticsText.style.display = 'none';
    hourlyText.style.display = 'none';
    aboutText.style.display = 'block';

    active.classList.remove('active');
    active = about;
    active.classList.add('active');
})

let tableDiv = document.getElementById('table-container');
let table = document.createElement('TABLE');
tableDiv.appendChild(table);

function weatherForFiveDays(data){

  let baseUrl = 'https://api.openweathermap.org/data/2.5/forecast';
  let apiKey = '53d85d2e0f34635d48c880206ce1e69e';
  let url = `${baseUrl}?q=${City.value}&units=metric&APPID=${apiKey}`;
  
  let elements = ['Icon', 'Description', 'Date and Time', 'Temperature', 'Humidity', 'Wind Speed'];

  let tHead = document.createElement('THEAD');
  let tBody = document.createElement('TBODY');
  table.appendChild(tHead);
  table.appendChild(tBody);

  for(let i=0; i<elements.length; i++){
      let th = document.createElement('TH');
      tHead.appendChild(th);
      th.innerText = elements[i];
  }

  fetch(url)
    .then(function(res){
      return res.json();
    })
    .then(function(data){

      for(let i=0; i<data.list.length; i++){
        let stats = [
                    data.list[i].weather[0].icon,
                    data.list[i].weather[0].description,
                    data.list[i].dt_txt,
                    data.list[i].main.temp,
                    data.list[i].main.humidity,
                    data.list[i].wind.speed
        ];

        let tr = document.createElement('TR');
        tBody.appendChild(tr);

        for (let j = 0; j < stats.length; j++) {
          let td = document.createElement("TD");
          tr.appendChild(td);

          if (j === 0) {
            let iconUrl = `http://openweathermap.org/img/w/${data.list[i].weather[0].icon}.png`;
            let iconImg = document.createElement('img');
            iconImg.setAttribute('src', iconUrl);
            td.appendChild(iconImg);
          } else {
            td.innerText = stats[j];
          }
        }
      }
    })
    .catch(function(err){
      tableDiv.innerText = 'Oops something went wrong, try again', err;
    })
}

function showStatistics() {

  let baseUrl = 'https://api.openweathermap.org/data/2.5/forecast';
  let apiKey = '53d85d2e0f34635d48c880206ce1e69e';
  let url = `${baseUrl}?q=${City.value}&units=metric&APPID=${apiKey}`;

      let maxTemp = -Infinity;
      let minTemp = Infinity;
      let totalTemp = 0;
      let totalHumidity = 0;
      let warmestTime;
      let coldestTime;

  fetch(url)
    .then(function(res){
      return res.json();
    })
    .then(function(data){
      
    
      // Find highest, lowest, and average temperature and humidity
      for(let i = 0; i < data.list.length; i++) {
        let temp = data.list[i].main.temp;
        let humidity = data.list[i].main.humidity;
        let dt = new Date(data.list[i].dt * 1000);
    
        if (temp > maxTemp) {
          maxTemp = temp;
          warmestTime = dt;
        }
    
        if (temp < minTemp) {
          minTemp = temp;
          coldestTime = dt;
        }
    
        totalTemp += temp;
        totalHumidity += humidity;
      }
    
      let avgTemp = totalTemp / data.list.length;
      let avgHumidity = totalHumidity / data.list.length;
    
      // Create table to display statistics
      let statsTable = document.createElement('table');
      statsTable.classList.add('statistics-table');
    
      let headerRow = statsTable.insertRow();
      let tempHeader = headerRow.insertCell();
      tempHeader.textContent = 'Temperature';
      tempHeader.setAttribute('colspan', 2);
      let humidityHeader = headerRow.insertCell();
      humidityHeader.textContent = 'Humidity';
      humidityHeader.setAttribute('colspan', 2);
    
      let dataRow = statsTable.insertRow();
      let maxTempCell = dataRow.insertCell();
      maxTempCell.textContent = maxTemp;
      let maxTempTimeCell = dataRow.insertCell();
      maxTempTimeCell.textContent = formatDate(warmestTime);
      let avgTempCell = dataRow.insertCell();
      avgTempCell.textContent = avgTemp.toFixed(1);
      let minTempCell = dataRow.insertCell();
      minTempCell.textContent = minTemp;
      let minTempTimeCell = dataRow.insertCell();
      minTempTimeCell.textContent = formatDate(coldestTime);
      let avgHumidityCell = dataRow.insertCell();
      avgHumidityCell.textContent = avgHumidity.toFixed(1);
    
      let tableContainer = document.getElementById('statistics-container');
      tableContainer.innerHTML = '';
      tableContainer.appendChild(statsTable);
    })

  
}

function formatDate(date) {
  let hours = date.getHours().toString().padStart(2, '0');
  let minutes = date.getMinutes().toString().padStart(2, '0');
  let dateString = `${date.toDateString()} ${hours}:${minutes}`;
  return dateString;
}



City.addEventListener('change', function(){
  weatherForFiveDays();
  showStatistics()
})



  



