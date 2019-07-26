# Customer Support API
 
 This is a simple web RESTful api that perform restful operations and basic CRUD operations on a MsSQL database
 
 ### Endpoints available
 
 | Endpoint                     | HTTP Methods           | Description                                                                |
 | -----------------------------|------------------------|----------------------------------------------------------------------------|
 | /api/complaints              | GET, POST              | Performs a 'Get' and 'Post' () operations and returns content of type json |
 | /api/complaints/{id}         | GET, PUT, DELETE       | 'Get' a single complain, 'Put' update complain and 'Delete'complain        |
 | /api/complaints/unit/{id}    | GET                    | 'Get' all complaints sent to CompanyUnit of {id}                           |
