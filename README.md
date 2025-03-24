Prerrequisitos:
• Tener una instancia de SQL Server
• Ejecutar el script llamado “DBSetup.sql”, el script crea la base de datos StoreSample, crea
esquemas, crea tablas, crea índices, inserta registros en las tablas, crea vistas y crea los precedures necesarios para el funcionamiento.


iniciar el app desde visual estudio o publicando la misma en iis o con el contenedor docker creado donde esta la app y el servicio para la base de datos

para las respectivas consultas ejecutar 

Sales Date Prediction
  url: /api/sales/sp_get_sales_date_predicion  
  metodo: get
  
Get Client Orders 
  url: /api/sales/sp_get_Orders_for_client  
  metodo: post
 cuerpo: {CustomerID = 9}
 
Get employees
  url: /api/sales/sp_get_employees  
  metodo: get
  
Get Shippers
  url: /api/sales/sp_get_Shippers  
  metodo: get
  
Get Products
  url: /api/sales/sp_get_Products  
  metodo: get

Add New Order
url: /api/sales/sp_set_new_orders  
  metodo: post
 cuerpo: {
    "Empid": 2,
    "Shipperid": 2,
    "Shipname": "andres escobar",
    "Shipaddress": "Carrera 1a #41-03",
    "Shipcity": "Tunja",
    "Shipcountry": "Colombia",
    "Orderdate": "2025-03-13T05:00:00.000Z",
    "Requireddate": "2025-03-06T05:00:00.000Z",
    "Shippeddate": "2025-03-19T05:00:00.000Z",
    "Freight": 52000,
    "Productid": 50,
    "Unitprice": 2,
    "Qty": 1,
    "Discount": 11,
    "custid": 5
}
