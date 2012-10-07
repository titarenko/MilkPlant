# Milk Plant #

The goal of project is to test several approaches for doing data persistence and data access in multi-layered applications

## Domain Entities ##

![Domain Entities](http://yuml.me/e0981434)

## Domain Logic (Set of Services) ##

![Domain Logic](http://yuml.me/1e462ca1)

## Common Flow: ##

- add trucks
- add products
- add distributors
- save warehouse operations history
- calculate delivery plan (essential operation) which is based on previously imported (inserted) data

## Delivery Plan Calculation Rules ##

- produced products should be delivered firstly to distibutors which are selling best and which will be first to run out of stock
- volume of stock and sales rate are calculated for 10-day plan period - that is to calculate need for certain product for plan period, sales rate should be multiplied by 10, and sales rate itself should be calculated using 10-day history of sales (today, yestrday, ..., today - 10 days)
- expected end result is plan for truck drivers: when, how many, and where they should deliver certain product
- such plan is calculated daily and should contain entries with certain constant date and varying (from 00:00 till 23:59) time
- to calulate time of delivery average truck speed and distance to distributor should be used (but do not forget to multiply this time by two - truck is going there and back), time for rest should not be considered as it is already accounted in truck average speed