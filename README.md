# exsb21-t4-services
Exadel Sandbox 2021, Team4, backend services

swagger-ui you can use from this url: https://localhost:5001/swagger/index.html


Please, could you check service in your computer

for registration: [GET] https://localhost:5001/oauth/{email}

for get events : [GET] https://localhost:5001/api/google/events/{email}

for create new event : [POST] https://localhost:5001/api/google/events/
                                      
                                      body=>{
        "summary": "Simple Test Summary",
        "description": "Simple description",
        "start": {
            "dateTime": "11/13/2021 09:30:00",
            "timeZone": "Europe/Minsk"
        },
        "end": {
            "dateTime": "11/13/2021 09:50:00",
            "timeZone": "Europe/Minsk"
        }
}


