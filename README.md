# Milk Plant #

The goal of project is to test several approaches for doing data persistence and data access in multi-layered applications

## Domain Entities ##

![Domain Entities](http://yuml.me/fe104dad)

## Domain Logic (Set of Services) ##

![Domain Logic](http://yuml.me/1512125f)

## Common Flow: ##

- add products
- add distributors
- add trucks
- save warehouse operations history
- calculate delivery plan (essential operation) which is based on previously imported (inserted) data

## Delivery Plan Calculation Rules ##

- produced products should be delivered firstly to distributors which are selling best and which will be first to run out of stock
- volume of stock and sales rate are calculated for 10-day plan period - that is to calculate need for certain product for plan period, sales rate should be multiplied by 10, and sales rate itself should be calculated using 10-day history of sales (today, yesterday, ..., today - 10 days)
- expected end result is plan for truck drivers: when, how many, and where they should deliver certain product
- such plan is calculated daily and should contain entries with certain constant date and varying (from 08:00 till 20:00) time
- to calculate time of delivery average truck speed and distance to distributor should be used (but do not forget to multiply this time by two - truck is going there and back), time for rest should not be considered as it is already accounted in truck average speed

## For Collaborators ##

If you want to implement backend, let's say, using MongoDB, please create branch with name in format "{Technology}-{YourName}" and then commit only to this branch. Then, when everything is ready, please do pull request to see your implementation in master branch which is considered to be stable.