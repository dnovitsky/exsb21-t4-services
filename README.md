# exsb21-t4-services
Exadel Sandbox 2021, Team4, backend services

swagger-ui you can use from this url: https://localhost:5001/swagger/index.html


Please, could you check service in your computer

for registration: [GET] https://localhost:5001/oauth

for new token:  [GET] https://localhost:5001/oauth/refresh

for delete permission: [GET]  https://localhost:5001/oauth/revoke

for get events : [GET] https://localhost:5001/api/google/events

for create new event : [POST] https://localhost:5001/api/google/events/create
                                      
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

Please, can you change GOOGLE_CLIENT_SECRET_PATH and GOOGLE_TOKEN_PATH in the code before run project   

Postman JSON Files in the GoogleFiles Folder
