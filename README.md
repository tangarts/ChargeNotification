# Charge Notification API

API to create invoices as outlined by the [specification](./spec.md).

## Example query

To get the invoice for customer with id 5 on the 1st March 2022, displayed as a pdf:

```
GET /api/invoice/5?pdf=true&date=2022-03-01
```

Note, the `wkhtmltopdf` is built for MacOS 10.7+.

To initialise the database create a database called `dbo` using postgres and run the sql script using `psql -f customer.sql -d dbo`.
