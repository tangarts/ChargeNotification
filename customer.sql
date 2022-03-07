CREATE OR REPLACE FUNCTION createCustomer(int) RETURNS void AS $$
 DECLARE
 amt int:=$1;
 BEGIN
 FOR counter IN 1..amt
 LOOP
 insert into customer(id, name)
  select counter, 'Customer' || Cast(counter as VARCHAR(50));
 END LOOP;
 END;
 $$ LANGUAGE plpgsql;

CREATE OR REPLACE FUNCTION randint(low INT ,high INT) 
   RETURNS INT AS $$
BEGIN
   RETURN floor(random()* (high-low + 1) + low);
END;
$$ LANGUAGE plpgsql;

CREATE OR REPLACE FUNCTION rand_day()
    RETURNS DATE AS $$
BEGIN 
    RETURN NOW() - '1 day'::INTERVAL * ROUND(RANDOM() * 7);
END;
$$ LANGUAGE plpgsql;

CREATE OR REPLACE FUNCTION createGameCharge(int) RETURNS void AS $$
 DECLARE
 amt int:=$1;
 cnt int:=(select count(*) from customer);
 BEGIN
 FOR counter IN 1..amt
 LOOP
 insert into gamecharge(customerid, description, totalcost, chargedate)
  select randint(1, 100), 'Game '  || Cast(randint(1, 21) AS VARCHAR(50)), randint(1, 100), rand_day();
 END LOOP;
 END;
 $$ LANGUAGE plpgsql;

create table customer(
    id SERIAL PRIMARY KEY,
    name VARCHAR(50) NOT NULL
    );

create table gamecharge (
    id SERIAL PRIMARY KEY, 
    customerId INTEGER, 
    description VARCHAR(100), 
    TotalCost INTEGER, 
    ChargeDate Date);
