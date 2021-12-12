-- noinspection SqlDialectInspectionForFile

-- noinspection SqlNoDataSourceInspectionForFile

use master
CREATE DATABASE Inventory
GO

USE Inventory
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create table Stock
(
    Id                             bigint identity constraint Stock_PK primary key,
    InventoryItemId                bigint                           not null,
    LocationId                     bigint                           not null,
    StatusId                       bigint                           not null,
    WarehouseId                    bigint                           not null,
    CreatedDate                    datetime                         not null,
    IsFrozen                       bit default 0,
    ReservationId                  bigint,
    SupplierId                     bigint,
)
go


USE Inventory
EXEC sys.sp_cdc_enable_db


USE Inventory
GO
EXEC sys.sp_cdc_enable_table
@source_schema = N'dbo',
@source_name = N'Stock',
@role_name = NULL,
@filegroup_name = N'',
@supports_net_changes = 0
GO

INSERT INTO Inventory.dbo.Stock (InventoryItemId, LocationId, StatusId, WarehouseId, CreatedDate, IsFrozen, ReservationId, SupplierId) 
VALUES (1, 2, 3, 300, GETDATE(), 0, 20, 241);