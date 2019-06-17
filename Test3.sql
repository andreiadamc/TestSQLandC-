CREATE TABLE categories (
cat_id numeric(9,0) NOT NULL,
cat_name varchar(100) NULL,
CONSTRAINT categories_pk PRIMARY KEY (cat_id)
);

CREATE TABLE products (
product_id numeric(9,0) NOT NULL,
product_name varchar(100) NULL,
CONSTRAINT products_pk PRIMARY KEY (product_id)
);

CREATE TABLE cat_to_products (
cat_id numeric(9,0) NOT NULL,
product_id numeric(9,0) NOT NULL,
CONSTRAINT cat_to_products PRIMARY KEY (cat_id, product_id)
);

select product_name, cat_name from products p1 
left join cat_to_products cp1 on p1.product_id= cp1.product_id
left join categories c1 on cp1.cat_id = c1.cat_id