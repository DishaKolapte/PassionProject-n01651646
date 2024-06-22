# PawCare-Pet Adoption App. 
Your trusted place for adopting a new furry friend. Find your perfect pet today. Our mission is to connect loving families with pets in need of a forever home. This project leverages ASP.NET MVC for the frontend, ASP.NET Web API for backend services.
## Features
- Pets: Create, Read, Update, and Delete pet data.
- Inquiries: Manage inquiries linked to pets.
- Relational Data: Handle relationships between pets and inquiries.

## Running this Project
### Prerequisites
- Visual Studio
- .NET Framework
## API calls
- Check code comments/ summary blocks for all the necessary API commands.
  
### Model Relationships
- Pet: A pet can have many inquiries.
- Inquiry: Each inquiry is associated with a pet and a user.

### Table Relationship
- Pet Table: `PetId` (Primary Key), `Name`, `Species`, `Breed`, `Age`
- Inquiry Table: `InquiryId` (Primary Key), `InquiryText`, `PetId` (Foreign Key), `UserId` (Foreign Key)

### Setup
**Clone the Repository:**
   ```bash
   git clone https://github.com/your-repo/PassionProject_n01651646.git
   ```

