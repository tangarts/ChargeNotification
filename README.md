# Charge Notification API

API to create invoices as outlined by the [specification](./spec.md).

## Example query

To get the invoice for customer with id 5 on the 1st March 2022, displayed as a pdf:

```
GET /api/invoice/5?pdf=true&date=2022-03-01
```
