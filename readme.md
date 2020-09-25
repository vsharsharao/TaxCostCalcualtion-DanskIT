
# Tax calculator for cities

This is a simple web application to calculate tax for a particular city on a given date.
* Bulk insert of the tax can be done using a json file
* Single record insert is possible using the API. API links are given below.
* A get request can fetch you the tax calculated on the given date and city.
* A sample .Net core console application is added to the main solution to demonstrate the GET functionality.


###### API Links
GET : /api/Tax/GetTaxInfo?city=Copenhagen&date=2016-03-16
POST : /Tax/TaxDataUpload/   (application/json)
POST : /api/Tax/BulkTaxDataUpload  (multipart/form-data)

###### Sample Input format
```javascript
{
  "City": "Copenhagen",
  "Schedule": [
    {
      "ScheduleType": "daily",
      "TaxCost": 0.1,
      "ScheduleRanges": [
        {
          "StartDate": "2016-01-01",
          "EndDate": "2016-01-01"
        },
        {
          "StartDate": "2016-12-25",
          "EndDate": "2016-12-25"
        }
      ]
    }
  ]
}
```

###### Sample bulk insert json file example
```javascript
[{
  "City": "Test",
  "Schedule": [
    {
      "ScheduleType": 0,
      "TaxCost": 0.1,
      "ScheduleRanges": [
        {
          "StartDate": "2020-01-01",
          "EndDate": "2020-01-01"
        },
        {
          "StartDate": "2020-06-30",
          "EndDate": "2020-06-30"
        }
      ]
    },
    {
      "ScheduleType": 1,
      "TaxCost": 0.2,
      "ScheduleRanges": [
        {
          "StartDate": "2020-05-01",
          "EndDate": "2020-12-01"
        }
      ]
    }
  ]
}]
```
