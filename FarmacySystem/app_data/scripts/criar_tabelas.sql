CREATE TABLE suppliers (
    id SERIAL PRIMARY KEY NOT NULL,
    name VARCHAR(255),
    cnpj VARCHAR(14),
    phone VARCHAR(16),
    zip_code VARCHAR(8),
    number INT
);

CREATE TABLE medicines (
    id SERIAL PRIMARY KEY NOT NULL,
    name VARCHAR(255),
    description TEXT,
    type VARCHAR(255),
    price DECIMAL(10,2),
    expiration_date DATE
);

CREATE TABLE suppliers_medicines (
    id SERIAL PRIMARY KEY NOT NULL,
    supplier_id INT NOT NULL,
    medicine_id INT NOT NULL,
    FOREIGN KEY (supplier_id) REFERENCES suppliers(id) ON DELETE CASCADE,
    FOREIGN KEY (medicine_id) REFERENCES medicines(id) ON DELETE CASCADE
);

CREATE TABLE stocks (
    id SERIAL PRIMARY KEY NOT NULL,
    quantity INT,
    updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    medicine_id INT NOT NULL,
    FOREIGN KEY (medicine_id) REFERENCES medicines(id) ON DELETE CASCADE
);

CREATE TABLE users (
    id SERIAL PRIMARY KEY NOT NULL,
    name VARCHAR(255),
    role VARCHAR(255),
    cpf VARCHAR(18),
    password VARCHAR(255)
);

CREATE TABLE sales (
    id SERIAL PRIMARY KEY NOT NULL,
    customer VARCHAR(255),
    sale_date DATE,
    total_value DECIMAL(10,2),
    user_id INT NOT NULL,
    FOREIGN KEY (user_id) REFERENCES users(id) ON DELETE CASCADE
);

CREATE TABLE sales_medicines (
    id SERIAL PRIMARY KEY NOT NULL,
    quantity INT,
	controlled boolean,
    sale_id INT NOT NULL,
    stock_id INT NOT NULL,
    FOREIGN KEY (sale_id) REFERENCES sales(id) ON DELETE CASCADE,
    FOREIGN KEY (stock_id) REFERENCES stocks(id) ON DELETE CASCADE
);

CREATE TABLE reports (
    id SERIAL PRIMARY KEY NOT NULL,
    description TEXT,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    user_id INT NOT NULL,
    FOREIGN KEY (user_id) REFERENCES users(id) ON DELETE CASCADE
);
