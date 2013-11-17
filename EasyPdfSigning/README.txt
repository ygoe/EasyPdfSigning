EasyPdfSigning
(Easy PDF signing / Einfache PDF-Signierung)
released under the GNU GPL license version 2 or newer
by Yves Goergen
http://unclassified.de/
designed for Windows 7/8

---------- Legal references ----------

Based on code of the iSafePDF project
by Alaa-eddine Kaddouri (France)
released under the GNU GPL license version 2
http://isafepdf.eurekaa.org/
https://isafepdf.codeplex.com/
via http://www.codeproject.com/Articles/84797/iSafePDF-The-Open-Source-PDF-Signature-Tool (2010)
via http://www.codeproject.com/Articles/14488/E-signing-PDF-documents-with-iTextSharp (2006)

Using the iTextSharp library
released under the GNU AGPL license
for general PDF information retrieval and the actual signing function
http://sourceforge.net/projects/itextsharp/

Using code from the CodeProject article
"How To Convert PDF to Image Using Ghostscript API"
by Lord TaGoH (Italy)
for displaying the selected PDF document page in the preview window
http://www.codeproject.com/Articles/32274/How-To-Convert-PDF-to-Image-Using-Ghostscript-API (2010)

Using the Ghostscript library
released under the GNU AGPL license
as a dependency of the PdfToImage assembly
http://ghostscript.com/

Including helper code
released under the BSD license
by Yves Goergen
http://dev.unclassified.de/source/delayedcall
http://dev.unclassified.de/source/line
http://dev.unclassified.de/source/mousefilter
http://dev.unclassified.de/source/progressspinner

---------- Technical requirements ----------

This application depends on native code from the Ghostscript library and should only be built for
the x86 platform. It may also work for x64, but you need to replace the included file gsdll32.dll
by the one from a 64-bit Ghostscript installation. This file is copied from the application
directory\bin.

The version of the iTextSharp library currently needs to be exactly 5.2.1. Signature things have
changed a lot from iText 5.3.0 and probably a lot of rewriting is needed to upgrade to it. This
work is planned for the future to be able to take advantage of all possibilities.

The version of the Ghostscript native library currently needs to be exactly 8.64. At least version
9.10 does not produce any visible output. The reason for this incompatibility is unclear. The 8.64
download link is included in the CodeProject article referencing to it.
