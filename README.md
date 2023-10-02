# LicensingInformationRetrieval
A Proof of Concept to determine the licensing details of the fonts installed on a Windows System.

Font embeddability inherently specifies how the fonts could be used / embedded in a document and hence, are permissions towards using them. Any Windows font can have one among the below embeddability at any point in time. They are;

Installable - Allows fonts to be embedded in the document and installed in the computer permanently.

Editable -  Allows fonts to be embedded in the document but only temporarily installs the fonts in the system.

Print/preview - Allows fonts to be embedded in the document but only installs fonts temporarily in the system for printing purposes.

Restricted - Font cannot be embedded in a document.

Source - https://www.printivity.com/insights/embed-fonts-word/

This solution to retrieve the font details by reading the licensing flags of the associated .ttf files of the fonts. TTF implies - true type font, which are most widely used around.

