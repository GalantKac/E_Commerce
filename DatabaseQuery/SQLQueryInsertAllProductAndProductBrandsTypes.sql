GO

USE DB_E_Commerce

GO

/* INSERT Product type */
INSERT INTO T_ProductType (Name) VALUES ('Boards')
INSERT INTO T_ProductType (Name) VALUES ('Hats')
INSERT INTO T_ProductType (Name) VALUES ('Boots')
INSERT INTO T_ProductType (Name) VALUES ('Gloves')

/* INSERT Product Brand */
INSERT INTO T_ProductBrand (Name) VALUES ('Angular')
INSERT INTO T_ProductBrand (Name) VALUES ('NetCore')
INSERT INTO T_ProductBrand (Name) VALUES ('VS')
INSERT INTO T_ProductBrand (Name) VALUES ('React')
INSERT INTO T_ProductBrand (Name) VALUES ('Typescript')
INSERT INTO T_ProductBrand (Name) VALUES ('C#')

/* INSERT  Product */
INSERT INTO T_Product (Name, Description, Price, PicturePath, ProductTypeId, ProductBrandId) VALUES ('Angular Speedster Board 2000', 'Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.', 200, 'images/products/sb-ang1.png', 1, 1)
INSERT INTO T_Product (Name, Description, Price, PicturePath, ProductTypeId, ProductBrandId) VALUES ('Green Angular Board 3000', 'Nunc viverra imperdiet enim. Fusce est. Vivamus a tellus.', 150, 'images/products/sb-ang2.png', 1, 1)
INSERT INTO T_Product (Name, Description, Price, PicturePath, ProductTypeId, ProductBrandId) VALUES ('Core Board Speed Rush 3', 'Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.', 180, 'images/products/sb-core1.png', 1, 2)
INSERT INTO T_Product (Name, Description, Price, PicturePath, ProductTypeId, ProductBrandId) VALUES ('Net Core Super Board', 'Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Proin pharetra nonummy pede. Mauris et orci.', 300, 'images/products/sb-core2.png', 1, 2)
INSERT INTO T_Product (Name, Description, Price, PicturePath, ProductTypeId, ProductBrandId) VALUES ('React Board Super Whizzy Fast', 'Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.', 250, '"images/products/sb-react1.png', 1, 4)
INSERT INTO T_Product (Name, Description, Price, PicturePath, ProductTypeId, ProductBrandId) VALUES ('Typescript Entry Board', 'Aenean nec lorem. In porttitor. Donec laoreet nonummy augue.', 120, 'images/products/sb-ts1.png', 1, 5)
INSERT INTO T_Product (Name, Description, Price, PicturePath, ProductTypeId, ProductBrandId) VALUES ('Core Blue Hat', 'Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.', 10, 'images/products/hat-core1.png', 2, 2)
INSERT INTO T_Product (Name, Description, Price, PicturePath, ProductTypeId, ProductBrandId) VALUES ('Green React Woolen Hat', 'Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.', 8, 'images/products/hat-react1.png', 2, 4)
INSERT INTO T_Product (Name, Description, Price, PicturePath, ProductTypeId, ProductBrandId) VALUES ('Purple React Woolen Hat', 'Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.', 15, 'images/products/hat-react2.png', 2, 4)
INSERT INTO T_Product (Name, Description, Price, PicturePath, ProductTypeId, ProductBrandId) VALUES ('Blue Code Gloves', 'Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Proin pharetra nonummy pede. Mauris et orci.', 15, 'images/products/glove-code2.png', 4, 3)
INSERT INTO T_Product (Name, Description, Price, PicturePath, ProductTypeId, ProductBrandId) VALUES ('Purple React Gloves', 'Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa.', 16, 'images/products/glove-react1.png', 4, 4)
INSERT INTO T_Product (Name, Description, Price, PicturePath, ProductTypeId, ProductBrandId) VALUES ('Green React Gloves', 'Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Proin pharetra nonummy pede. Mauris et orci.', 14, 'images/products/glove-react2.png', 4, 4)
INSERT INTO T_Product (Name, Description, Price, PicturePath, ProductTypeId, ProductBrandId) VALUES ('Redis Red Boots', 'Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.', 250, 'images/products/boot-redis1.png', 3, 6)
INSERT INTO T_Product (Name, Description, Price, PicturePath, ProductTypeId, ProductBrandId) VALUES ('Core Red Boots', 'Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.', 189.99, 'images/products/boot-core2.png', 3, 2)
INSERT INTO T_Product (Name, Description, Price, PicturePath, ProductTypeId, ProductBrandId) VALUES ('Core Purple Boots', 'Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Proin pharetra nonummy pede. Mauris et orci.', 199.99, 'images/products/boot-core1.png', 3, 2)
INSERT INTO T_Product (Name, Description, Price, PicturePath, ProductTypeId, ProductBrandId) VALUES ('Angular Purple Boots', 'Aenean nec lorem. In porttitor. Donec laoreet nonummy augue.', 150, 'images/products/boot-ang2.png', 3, 1)
INSERT INTO T_Product (Name, Description, Price, PicturePath, ProductTypeId, ProductBrandId) VALUES ('Angular Blue Boots', 'Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.', 180, 'images/products/boot-ang1.png', 3, 1)
