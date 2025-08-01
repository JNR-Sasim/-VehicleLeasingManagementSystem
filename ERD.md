# Entity Relationship Diagram (ERD)
## Vehicle Leasing Management System

```
┌─────────────────────────────────────────────────────────────────────────────────┐
│                                VEHICLE                                        │
├─────────────────────────────────────────────────────────────────────────────────┤
│ PK: VehicleId (int)                                                           │
│ LicensePlate (string, 50) - Required                                         │
│ Make (string, 100) - Required                                                │
│ Model (string, 100) - Required                                               │
│ Year (int) - Required                                                         │
│ Color (string, 50) - Required                                                │
│ FuelType (string, 20) - Required                                             │
│ EngineSize (decimal) - Required                                              │
│ Mileage (int) - Required                                                      │
│ DailyRate (decimal) - Required                                                │
│ Status (string) - Default: "Available"                                       │
│ RegistrationDate (DateTime) - Required                                        │
│ LastServiceDate (DateTime?) - Optional                                       │
│ NextServiceDue (DateTime?) - Optional                                         │
├─────────────────────────────────────────────────────────────────────────────────┤
│ FK: SupplierId (int) - Required → SUPPLIER                                   │
│ FK: BranchId (int) - Required → BRANCH                                       │
│ FK: ClientId (int?) - Optional → CLIENT                                      │
│ FK: DriverId (int?) - Optional → DRIVER                                      │
└─────────────────────────────────────────────────────────────────────────────────┘
                                    │
                                    │
                    ┌────────────────┼────────────────┐
                    │                │                │
                    ▼                ▼                ▼
┌─────────────────┐  ┌─────────────────┐  ┌─────────────────┐
│    SUPPLIER     │  │     BRANCH      │  │     CLIENT      │
├─────────────────┤  ├─────────────────┤  ├─────────────────┤
│ PK: SupplierId  │  │ PK: BranchId    │  │ PK: ClientId    │
│ Name (100)      │  │ Name (100)      │  │ CompanyName(100)│
│ Address (200)   │  │ Address (200)   │  │ ContactPerson(50)│
│ City (50)       │  │ City (50)       │  │ Address (200)   │
│ State (20)      │  │ State (20)      │  │ City (50)       │
│ PostalCode (10) │  │ PostalCode (10) │  │ State (20)      │
│ Country (50)    │  │ Country (50)    │  │ PostalCode (10) │
│ Phone (20)      │  │ Phone (20)      │  │ Country (50)    │
│ Email (100)     │  │ Email (100)     │  │ Phone (20)      │
│ Website (100)   │  │ Manager (50)    │  │ Email (100)     │
│ ContactPerson(50)│  │ OpeningHours(100)│  │ Website (100)   │
│ RegistrationDate │  │ BranchCode (10) │  │ TaxId (20)      │
│ IsActive (bool) │  │ EstablishmentDate│  │ BusinessLicense │
│ Notes (500)     │  │ IsActive (bool) │  │ RegistrationDate│
└─────────────────┘  │ Description(500)│  │ IsActive (bool) │
                     └─────────────────┘  │ Notes (500)     │
                                         │ CreditLimit     │
                                         │ PaymentTerms(50)│
                                         └─────────────────┘
                    │
                    ▼
┌─────────────────┐
│     DRIVER      │
├─────────────────┤
│ PK: DriverId    │
│ FirstName (50)  │
│ LastName (50)   │
│ DriverLicense(20)│
│ LicenseExpiryDate│
│ Phone (20)      │
│ Email (100)     │
│ Address (200)   │
│ City (50)       │
│ State (20)      │
│ PostalCode (10) │
│ Country (50)    │
│ DateOfBirth     │
│ HireDate        │
│ IsActive (bool) │
│ EmergencyContact│
│ EmergencyPhone  │
│ Notes (500)     │
└─────────────────┘

```

## Relationships:

### 1. Vehicle → Supplier (Many-to-One)
- **Relationship**: Each vehicle must have one supplier
- **Cardinality**: Many vehicles can belong to one supplier
- **Foreign Key**: Vehicle.SupplierId → Supplier.SupplierId

### 2. Vehicle → Branch (Many-to-One)
- **Relationship**: Each vehicle must be allocated to one branch
- **Cardinality**: Many vehicles can be allocated to one branch
- **Foreign Key**: Vehicle.BranchId → Branch.BranchId

### 3. Vehicle → Client (Many-to-One, Optional)
- **Relationship**: A vehicle can be leased to one client (optional)
- **Cardinality**: Many vehicles can be leased to one client
- **Foreign Key**: Vehicle.ClientId → Client.ClientId (nullable)

### 4. Vehicle → Driver (Many-to-One, Optional)
- **Relationship**: A vehicle can be assigned to one driver (optional)
- **Cardinality**: Many vehicles can be assigned to one driver
- **Foreign Key**: Vehicle.DriverId → Driver.DriverId (nullable)

## Key Features:
- **Central Entity**: Vehicle is the core entity connecting all others
- **Required Relationships**: Every vehicle must have a supplier and branch
- **Optional Relationships**: Vehicles can optionally be leased to clients and assigned to drivers
- **Flexible Leasing**: A vehicle can be available (no client/driver) or leased (with client/driver)

## Business Logic:
1. **Procurement**: Vehicle is procured from a Supplier
2. **Allocation**: Vehicle is allocated to a Branch
3. **Leasing**: Vehicle can be leased to a Client (optional)
4. **Operation**: Vehicle can be assigned to a Driver (optional) 