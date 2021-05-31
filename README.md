# deliveryApiGit

Данные сохраняются в MS SQL, 
для подключения необходимо указать ConnectionString в appsetings,
при создании базы данных заполняются таблицы:
- магазины,
- постаматы,
- статусы,

АПИ проверяет поле "x-api-key" в headers,
для тестов можно использовать api key одного из магазинов:
headers["x-api-key"] = "a5d36b4a-ac93-43bd-b6ce-4c8456b445a4"

Endpoints:
Просмотр заказа:
GET
/api/tracking/1

Просмотр постамата:
GET
/api/postamat/1

Добавление заказа:
POST
/api/order/add
{
"Number":1,
"products": [
        "product 1",
        "product 2",
        "product 3"
    ],
"Cost":1,
"Postamat": 1,
"Phone":"+7900-100-10-01",
"Recipient":"Билл Маркович Брин"
}

Обновление заказа:
PUT
/api/order/1
{
"Products": [
        "product 1"
    ],
"Cost":1,
"Postamat": 1,
"Phone":"+7900-100-10-02",
"Recipient":"Питт Леонардо Арнольдович"
}

Отмена заказа:
DELETE
/api/order/1

GET
/endpoints
