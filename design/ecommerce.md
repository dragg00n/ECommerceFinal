# ECommerce API


## Placing An Order

To place an order, you POST a document like this:

### Request
```
POST /orders
Content-Type: "application/json"
Accept: "application/json"
```
```json
{
    "name": "Bob Smith",
    "address": "1212 Mockingbird Ct",
    "city": "Lakewood",
    "state": "OH",
    "zip": "44107",
    "creditCardInfo": {
        "number": "555-55-5555",
        "expiration": "06/22",
        "cvv2": "999"
    },
    "items": [
        { "id": "1", "name": "Beer", "qty": 6, "price": 1.99},
        { "id": "2", "name": "More Beer", "qty": 12, "price": 99},
        { "id": "3", "name": "Chips", "qty": 1, "price": 3.99},
    ]
}

```

### Response (Happy!)

```
201 Created
Content-Type: "application/json"
Location: "http://localhost:1337/orders/3"
```
```json
{
    "orderNumber": "3",
    "message": "We have placed your order!",
    "shipDate": "2021-11-1",
    "amountCharged": 69.99, 
    "tax": 3.00,
    "shipping": 4.25
}


```
### Response (Sad!)