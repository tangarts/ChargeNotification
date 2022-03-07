# Task

Create a solution that will generate a customer charge notification in PDF format using C#. The
solution must be able to create 30,000 charge notifications in a timely fashion.

## Scenario:

- Company Z is a gaming software company and has ~20 games available to their customers.
- Company Z’s games are free to use/download
- Company Z’s games come with chargeable items (these can be anything from level cheats to
power boosts, armour, weapons, skin etc).
- Company Z has more than 1 million customers
- Company Z charges their customer on a daily basis.
- Company Z must notify their customers for any incurred charges (charge notification)
- Charges are grouped by game, so if a customer plays 3games and used one or more
chargeable items in each of the games then an overall total charge amount for each game (in
this example, there will be 3 total charge amounts 1 per game – see Table 1) will be printed
on the charge notification
- Company Z issues in average about 30,000 charge notifications each day


| Description  | Charge Description    | Cost (pence)   | Total (pence)   | Charge Date     |
| ------------ | --------------------- | -------------- | --------------- | --------------- |
| Game 1       | • New Skin            | 5              | 15              | 20/05/2022      |
|              | • Power boost         | 10             |                 |                 |
| Game 2       | • Diamond armour      | 5              | 55              | 20/05/2022      |
|              | • Level cheat sheet   | 50             |                 |                 |
| Game 3       | • Level Up            | 75             | 75              | 20/05/2021      |


## Charge Notification Template

```
Customer Number: 1  
Customer Name: Customer1

**CHARGES**

| Date       | Game   | Cost (pence) |
| ---------- |--------| ------------ |
| 20/05/2021 | Game 1 | 15           |
| 20/05/2021 | Game 2 | 55           |
| 20/05/2021 | Game 3 | 75           |

**TOTAL (pence): 145**
```

## Useful Pointers:

- For the purposes of this task please stick to a bare minimum of 2 SQL tables (Customer &
CustomerGameCharge – the latter could contain information like Id, CustomerId,
Description, TotalCost, ChargeDate)
- Please consider maintaining database referential integrity when designing your SQL tables
- The charge notification template can be in any format (html, xsl etc)
- The output of the charge notification must be in PDF format
- The solution could be anything, webAPI, windows service, console app, dll, UI (stick with
whatever you feel most comfortable with)
- To populate the Customer table, and avoid manually populating the table, consider using
below SQL script:

```SQL
create table dbo.Customer (CustomerNumber int, CustomerName varchar(50))
declare @count int = 1
while @count <=40000
begin
insert into dbo.Customer(CustomerNumber, CustomerName)
select @count, 'Customer' + convert(varchar(10), @count)
set @count=@count+1
end
```
