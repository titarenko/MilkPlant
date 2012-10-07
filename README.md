# Milk Plant #

The goal of project is to test several approaches for doing data persistence and data access in multi-layered applications

## Domain entities are depicted on following diagram ##

![Domain Entities](http://yuml.me/e0981434)

## Domain logic (set of services) is depicted on following diagram ##

![Domain Logic](http://yuml.me/1e462ca1)

## Common flow: ##

- add trucks
- add products
- add distributors
- save warehouse operations history
- calculate delivery plan (essential operation) which is based on previously imported (inserted) data