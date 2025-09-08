# Event Management Portal

## About the Project
This is a simple Angular application built for a company that organizes conferences, workshops, and music concerts.  
It shows a list of upcoming events, formats ticket prices nicely, and highlights premium events so they stand out.

--------------------------------------------------------------

## What I Built
- **Event List Component (`EventListComponent`)**  
  Displays all upcoming events with their Name, Date, Ticket Price, and Category. The list is dynamically generated using Angular's `*ngFor`.

- **Custom Pipe (`PriceFormatPipe`)**  
  Formats the ticket prices into Indian currency format.  
  Example: `3500` → `₹3,500.00`.

- **Custom Directive (`HighlightDirective`)**  
  Highlights events with ticket prices above ₹2000 by changing the row background to light gold.

- **Animations**  
  Added smooth fade-in effect for a better user experience.

--------------------------------------------------------------

## How to Run
1. Download or clone the project folder.  
2. Open the terminal in the project folder.  
3. Install dependencies:

```bash
npm install
ng serve