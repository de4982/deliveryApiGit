# deliveryApiGit
 
GET
/api/postamat/2

DELETE
/api/order/2

PUT
/api/order/2
{
"Products": [
        "product 1"
    ],
"Cost":7,
"Postamat": 1,
"Phone":"+7900-333-22-02",
"Recipient":"recipient 2"
}

POST
/api/order/add
{
"Number":3,
"products": [
        "product 1",
        "product 2",
        "product 3"
    ],
"Cost":1,
"Postamat": 4,
"Phone":"+7900-100-10-01",
"Recipient":"Билл Маркович Брин"
}

GET
/api/tracking/2
GET
/endpoints
