create table suppliers (
	id serial primary key not null,
	name varchar(255),
	cnpj varchar(14),
	phone varchar(16),
	zip_code varchar(8),
	number int
);

create table medicines (
	id serial primary key not null,
	name varchar(255),
	description text,
	type varchar(255),
	price decimal(10,2),
	expiration_date date
);

create table suppliers_medicines(
	id serial primary key not null,
	supplier_id int not null,
	medicine_id int not null,
	foreign key (supplier_id) references suppliers(id),
	foreign key (medicine_id) references medicines(id)
);

create table stocks(
	id serial primary key not null,
	quantity int,
	updated_at timestamp default current_timestamp,
	medicine_id int not null,
	foreign key (medicine_id) references medicines(id)
);

create table sales(
	id serial primary key not null,
	customer varchar(255),
	sale_date date,
	total_value decimal(10,2),
	user_id int not null,
	foreign key (user_id) references users(id)
);

create table sales_medicines(
	id serial primary key not null,
	quantity int,
	sale_id int not null,
	stock_id int not null,
	foreign key (sale_id) references sales(id),
	foreign key (stock_id) references stocks(id)
);

create table users (
	id serial primary key not null,
	name varchar(255),
	role varchar(255),
	cpf varchar(18),
	password varchar(255)
);

create table reports(
	id serial primary key not null,
	description text,
	created_at timestamp default current_timestamp,
	user_id int not null,
	foreign key (user_id) references users(id)
);

