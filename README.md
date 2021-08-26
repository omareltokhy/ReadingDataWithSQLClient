# Module 2 Reading Data SQL Client

Noroff .NET Fullstack - Module 2 weekly task


## Appendix A
Appendix A: We create SQL scripts and build console application in C#. The several scripts include such as create a database, setup some tables in the database, add relationships and populate tables with data.

Tables: 

Superhero, Assistant, Power.

Relationships: 

1: One Superhero can have multiple assistants, one assistant has one superhero they assist.


2: One superhero can have many powers, and one power can be present on many superheroes.

Solution for this is located in SuperHeroesSQL folder.

## Appendix B

Appendix B: In this task we manipulate SQL Server data with Visual Studio using a library called SQL Client. We are given a database to work with. Task is to create following functionality:

1. Read all the customers in the database and display id, firstname, lastname, country, postal code, phone number, email
2. Read a specific customer from the database(by id) and display everything listed above.
3. Read a specific customer from the database(by name) and display everything listed above.
4. Return a page of customers from the database
5. Add a new customer to the database.
6. Update existing customer.
7. Return a number of customers in each country.
8. Return customers who are the highest spenders in descending order.
9. Return most popular genre of music for given customer.

Solution is made with repository pattern and located in SqlClientRepoModule2 folder.

## Contribution
Ville Hotakainen, Omar El Tokhy.

## License
[MIT](https://choosealicense.com/licenses/mit/)

