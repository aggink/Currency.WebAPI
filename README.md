# Веб-API - получение данных о курсах валют от ЦБ РФ
Ежедневные данные о курсах валют ЦБ РФ доступны по ссылке: https://www.cbr-xml-daily.ru/daily_json.js

# Возможности:
* получение списка курсов валют с возможностью пагинации. Пример ответа:
```json
{
  "pageIndex": 1,
  "pageSize": 1,
  "totalCount": 34,
  "totalPages": 34,
  "startIndex": 1,
  "items": [
    {
      "id": "R01010",
      "numCode": 36,
      "charCode": "AUD",
      "nominal": 1,
      "name": "Австралийский доллар",
      "value": 41.8469,
      "previous": 43.4789
    }
  ],
  "hasPreviousPage": false,
  "hasNextPage": true
}
```
* получение курса валюты по ее идентификатору. Пример ответа:
```json
{
  "id": "R01200",
  "numCode": 344,
  "charCode": "HKD",
  "nominal": 10,
  "name": "Гонконгских долларов",
  "value": 76.7732,
  "previous": 79.1866
}
```
