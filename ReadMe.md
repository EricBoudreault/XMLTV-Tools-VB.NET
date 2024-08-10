# XMLTV-Tools
Outils développés en Visual Basic.NET pour faciliter la manipulation et la gestion de fichiers **XMLTV**.

XMLTV est un format standard pour la description des programmes télévisés, utilisé par de nombreux services de télévision et applications de gestion des programmes.

&nbsp;&nbsp;&nbsp;&nbsp;


## FilterEPG
**FilterEPG** sert à filtrer et alléger un fichier XMLTV pour ne garder que les chaînes désirées.

#### Fonctionnalités
- Filtrage des chaînes spécifiées dans un fichier XMLTV.
- Création d'un fichier XMLTV allégé contenant uniquement les chaînes sélectionnées.

#### Exemple d'utilisation
```sh
FilterEPG.exe "C:\source.xml" "CNN.us|BBCNews.uk|BFMParis.fr" "C:\destination.xml"
```
&nbsp;&nbsp;

## MergeEPG
**MergeEPG** sert à joindre deux fichiers XMLTV en un fichier unique.

#### Fonctionnalités
- Fusion de deux fichiers XMLTV.
- Création d'un fichier XMLTV combiné.


#### Exemple d'utilisation
```sh
MergeEPG.exe "C:\guide1.xml" "C:\guide2.xml" "C:\guide1+2.xml"
```
&nbsp;&nbsp;

## PrettyXMLTV
**PrettyXMLTV** indente et applique une mise en forme aux fichiers XMLTV pour une meilleure lisibilité.

#### Fonctionnalités
- Indentation.
- Mise en forme.


#### Exemple d'utilisation
```sh
PrettyXMLTV.exe "C:\guide.xml" "C:\guide.xml"
```
&nbsp;&nbsp;&nbsp;&nbsp;

## Prérequis
Assurez-vous d'avoir installé **Microsoft Visual Studio 2022 Community Edition** et être familiarisé avec **Microsoft Visual Basic .NET** et le **Framework .NET 4.8**.
