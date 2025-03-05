# Changelog

## v1.10

### Date and Time command changes

These are being changed to avoid name collision with other commands, and improve readability

- $d changed to $date
- $t changed to $time

### Using multiple lists from slots at once
- New commands: $lln1 $lln2 $lln3
These allow referencing lists of values from multiple slots when processing text from the Processing slot or Text Library.

Fill slots 1-3 with individual lists of values and reference one or multiple of them in another text.
Make sure to increment the number each time you process the text using $postinc (Increment the spinner number at the end)
Values in the lists will also be processed if any commands are present.
	
	Example:
	
	PROCESS SLOT:   ID: $number Name: $lln1, team: $lln2 $postinc
	MEMORY SLOT 1:  Joe
	                Mary
	                Frank
	                Sarah
	MEMORY SLOT 2:  Blue
	                Red
	                Green
	                Blue

	OUTPUT:         ID: 1, Name: Joe, team: Blue
	                ID: 2, Name: Mary, team Red
	                ID: 3, Name: Frank, team Green
	                ID: 4, Name: Sarah, team Blue



### Important change to number function

Changes to improve number control and List from Slot ($lln) commands

- $i,$+,$- function names removed
- $number replaces $i, Outputs the number.
- $postinc increments the number spinner after processing
- $postdec decrements the number spinner after processing
- $preinc increments the number spinner before processing
- $predec decrements the number spinner before processing

Only $number outputs the number spinner value, the others are silent

### Other changes
- Changelog is now shown after an application update
- Changelog can be opened from the Options menu

## v1.9

- Added Autorun option to start application when starting Windows
- Text processing: Digit to Word, converts numbers to numeral text
- Text prompt command can now handle multiple prompts in a text
- Improved Text History, double click Title to edit title and contents in a new window
- When adding new Text History entries, Cancel no longer adds a new unpinned entry
- Text History Add button now works with an empty clipboard

## v1.8

- Using .Net 8
- Bug fixes
- Rich text formatting option in text processing
- Various RTF options
- Options re-designed
- Auto save memory slots when exiting (option)
- Math equations in text processing
- History window renamed to Text Library

## v1.3

- History Window added. This lets you save text files and quickly load the entries to the clipboard.
- Added strong naming to the assembly to preserve settings between versions.
- Added $prompt command for inserting user input into a text

## v1.2

- Bug fixes

## v1.1

- Added $list command
- Added $rep Replace command
- Bugfixes
- Hotkey improvements

## v1.0

- Initial version
- Added date and time hotkeys
- Clipboard output options