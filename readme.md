<!-- This file is formatted with Markdown. While it's readable as plain text, some characters have a backslash \ escape character in front of them, these should be ignored-->
<!-- For best readability, view it at https://github.com/snjo/ClipboardTool-->
# Clipboard tool
*by Andreas Aakvik Gogstad*  
*2022*

Source code:  
https://github.com/snjo/ClipboardTool

Changelog:  
https://github.com/snjo/ClipboardTool/blob/master/changelog.md

![image](img/clipboardtool1.png)

-----------------------------------------
## Interface

#### Main window

The buttons in the main application window alter or replace the content of the clipboard. The hotkeys to perform the same operation are also listed, and can be changed in Options.

	Text Library - Opens a window with saved text entries, much like sticky notes.
	Toolbar - Opens a floating window with a small number of buttons.
	Ghost - Hides the main window from the task bar. Use the system tray, toolbar or hotkeys to control the program.
	Pin - Toggles on Always on top mode.
	Cogwheel - Opens Options

	lower - Converts text in the clipboard to lower case. Formatting is removed.
	UPPER - Converts text in the clipboard to upper case. Formatting is removed.
	Plain - Outputs the text in the clipboard. Formatting is removed.
	Caps Lock - Toggle the Caps Lock (useful if you have reassigned your Caps lock key)

	Process - Outputs the text in the large textbox below to the clipboard, performing any text processing using $ commands.
	Number spinner - This upDown number is used for various functions in text processing commands, referred to as "number".
	Large Text box - The text in this box is used by the Process button/hotkey.
	? - Help, opens a window with all text processing $ commands
	Save - Saves the contents of the text box to a file. This is automatically loaded when the program starts.

	Memory Slots, all three are identical:
	Text box - the contents of these boxes are used either as outputs from the 1/2/3 hotkeys, or referenced as variables by other $ commands
	Save - Saves the contents of the textbox to disk. This is automatically loaded when the program starts.
	Down arrow - Fills the textbox with the current contents of the clipboard.
	Up arrow - Outputs the text in the textbox to the clipboard, performing any text processing using $ commands.
	
#### TextLibrary Window
	
	Pin - Toggles on Always on top mode.
	Color - Change the color of the selected text entry
	Add - Creates a new text entry with the current contents of the clipboard
	
	Each entry has the following elements (columns):
	Pin - Saves the entry to a text file. Removing the pin deletes the file on disk.
	Title - A title for convenience. Must be a valid file name. Double click to edit title and contents.
	Text - The text that will be output. Text processing is performed on any $ commands.
	> - Copies the text to the clipboard.

	Text Library folder link - Opens the folder with any saved text entries.
	Minimize - If checked, the window minimizes after clicking a > button

See the Text Library Window section below for more details

-----------------------------------------
## Commands for text processing:

*Commands are case sensitive*

| Command   | Function                                                                  |
|-----------|---------------------------------------------------------------------------|
| $d        | current date                                                              |
| $t        | current time                                                              |
| $cp       | clipboard (plain text)                                                    |
| $cl / $cu | clipboard in lower/upper case                                             |
| $number   | output the number from the upDown spinner                                 |
| $postinc  | Increments the number of the spinner AFTER processing is done             |
| $postdec  | Decrements the number of the spinner AFTER processing is done             |
| $preinc   | Increments the number of the spinner BEFORE processing is done            |
| $predec   | Decrements the number of the spinner BEFORE processing is done            |
| $n2, $n3  | Flag: pad number with 1-2 zeroes (01, 001).                               |
| $m1 - $m3 | contents of the memory slots                                              |
| $eq       | Flag: Convert \"\" to \", and removes single \"                           |
| $rep      | Replace text in clipboard. Use mem slot 1 & 2 as from/to strings          |
| $vcm      | Split value in slot 1 with comma, output value[number]                    |
| $vsc      | Split value in slot 1 with semicolon, output value[number]                |
| $vsp      | Split value in slot 1 with space, output value[number]                    |
| $list     | Split lines in main textbox (skips line 1), output value[number]          |
| $prompt   | Opens a popup box to insert a text value                                  |
| $Math     | Flag: Solves equations enclosed in [] brackets                            |
| $Round    | Flag: Alters $Math to round off results.                                  |
| $RTF      | Flag: Output Rich text. See details below                                 |
| $DTW      | Translates digits in curly braces to numeral words. ex: $DTW{12} = twelve |
| $DTU      | Flag: output from DTW is all upper case                                   |

#### Flags

Commands marked as Flag do not output text directly, but alters the rest of the text or commands in some way.

-----------------------------------------
## Text Files in the program folder

By default the program looks for these files in the user profile folder. You can direct it to another folder on your PC it the Options panel.

| Text file              | Function                                                                          | Comment	                                                                                   |
|------------------------|-----------------------------------------------------------------------------------|---------------------------------------------------------------------------------------------|
| process.txt            | Preset contents of the Proccess text area (The main text box in the application). | You can update the text file by using the Save button next to the textbox (diskette icon)   |
| mem1.txt-mem3.txt      | Preset contents of the three memory slots at the bottom of the applications.      | Use this for commonly typed phrases, or as part of the commands in the process text field. The text file is only overwritten by the program if configured in the settings |

-----------------------------------------
## Hotkeys

The program settings user.config are stored in a folder in %localappdata%\ClipboardTool\

| Function                       | Default hotkey         |
|--------------------------------|------------------------|
| Convert to upper case          | Ctrl+Shift+U           |
| Convert to lower case          | Ctrl+Shift+L           |
| Convert to plain text          | Ctrl+Shift+T           |
| Process text using $'s         | Ctrl+Shift+P           |
| Caps Lock toggle               | Ctrl+Shift+Backspace   |
| Memory Slot 1                  | Ctrl+Shift+1           |
| Memory Slot 2                  | Ctrl+Shift+2           |
| Memory Slot 3                  | Ctrl+Shift+3           |
| Reset Number UpDown to 1       | Ctrl+Shift+R           |
| Date/Time                      | Ctrl+Shift+D           |
| Text Library Window            | Ctrl+Shift+H           |

Memory Slot hotkeys also does any $ processing in the field, but some functions are not suited for these slots since they rely on values in the mem slots ($rep, $vcm, $list etc.)

#### Date and time hotkey

Tap the date hotkey 1-3 times while holding the modifier keys:

	1: Types out just the date	
	2: Types out just the Time
	3: Types out the Date and Time

The date format is based on your Windows region settings, but can be overridden in the Options / Culture setting.

-----------------------------------------
## Text Library Window

The Text Library window allows you to save text and quickly load them into the clipboard. Any $ commands in the text will be processed if you use the [>] Copy button.

Set the folder for these text files in Options, or allow the program to create the folder for you when opening Text Library the first time.

The Minimize on Copy checkbox default setting can be saved in Options.

If you pin an entry, the file will be saved. Unpinning the entry will delete the file. Any entries that are not pinned (saved) will be lost if you close the Text Library window.

When adding a new entry from clipboard using the Add button, or pinning a manually created entry, you must specify a title.
This title will be used as the file name (.txt will be added automatically), you must use a valid file name.
If you have selected a color, the text file will begin with a color tag on the first line.

To edit title, contents and color, double click the title field. This will open a new window for easier editing of longer text entries.

#### Quick Tip
Set the Text Library hotkey to a convenient key like F2 (without modifiers), and set the "Minimize after copy" on in options.

Then while working in an application, you can press the hotkey, copy the text, and paste into your application.

-----------------------------------------

## Rich Text (RTF) output

If you add the $RFT command, the text will be output to the clipboard in Rich Text format, allowing for text styles, colors and font families.

Outputting this correctly requires using the clipboard. Set Options to use Ctrl+V instead of Send Keys. While using Send Keys option, the output will be in plain text.

Text can be marked up using either RTF codes such as "\b ", "\b0 " and more advanced codes, or using a small set of predefined tags.
These tags will self terminate when reaching the next tag, making them slightly easier to use than normal RTF codes.

Any Backslashes ( \ ) in RTF text will be intercepted as an RTF code. Use a double backslash to represent a backslash that should be output.
\\\\ = \\ 
<!-- If you're reading this as plain text: \\ = \ -->

| Tag                     | Effect                   |
|-------------------------|--------------------------|
| \<>                     | End previous tag         |
| \<b>                    | Bold                     |
| \<i>                    | Italic                   |
| \<plain>                | Plain text               |
| \<strike>               | Strikethrough            |
| \<ul>                   | Underline                |
| \<ulw>                  | Underline just words     |
| \<default>              | Font 0 Default           |
| \<serif>                | Font 1 Serif             |
| \<sans>                 | Font 2 Sans Serif        |
| \<mono>                 | Font 3 Monospace         |
| \<script>               | Font 4 Script            |
| \<decor>                | Font 5 Decorative        |
| \<fs**>                 | Size in half-points      |
|                         | Ex: £\<fs18> = 9 point   |
| \<cf*>                  | Color, see Colors section|
| \<red> \<black> etc.    | Predefined colors        |
| \<[RTF code without]>   | Ex: \<nl> = \\nl         |

When using normal RTF codes with a backslash, you must leave a space or other separator at the end of the tag.

*Example: "hello \\b world\\b0 " is OK, "hello \\bworld\\b0" is not.*
<!-- If you're reading this as plain text, ignore \ before tags. Use <>, not \<> -->

-----------------------------------------
### Colored text

Some colors are predefined as tags:
\<black>, \<white>, \<gray>, \<red>, \<green>, \<blue>

You can add more colors in Options in this format:
\\red0\\green80\\blue180;\\red255\\green0\\blue180;

You can reference these color values starting with number 7: \<cf7> or \\cf7
(The first six values are reserved by the predefined colors)

-----------------------------------------
### Font table

The font table can be customized in Options. When using values outside the predefined font tags, use RTF commands.

Example: \<f6> or \\f6  to use

-----------------------------------------
### Math equations

$Math: Solves equations enclosed in [] brackets.
$Round: Rounds off equation results to integers.

		Example: $Math[2+3]
		Output: 5

		Example: $Math[$cp+3]
		Output: if Clipboard is "2", result is 5

		Example: $Math[$i+3]
		Output: if Number spinner is "2", result is 5

		Example: $Math[2+(3/2)]
		Output: 3,5

		Example: $Math$Round[2+(3/2)]
		Output: 4

If there's an error in the equation, a warning popup is shown. This can be disabled in Options.

The datatable used to process the equation only works with US notation, so any commas will be converted to periods. The result will be output with commas or period as decimal separator based on the region/culture setting in Options. By default it uses your Windows region setting.


-----------------------------------------
## Key codes for hotkey options:
https://learn.microsoft.com/en-us/dotnet/api/system.windows.forms.keys?view=windowsdesktop-7.0

| Key                              | Keycode             |
|----------------------------------|---------------------|
| 0-9                              | 0 to 9              |
| A-Z                              | A to Z              |
| F1-F24                           | F1 to F24           |
| The BACKSPACE key                | Back                |
| The TAB key                      | Tab                 |
| The RETURN key                   | Return              |
| The ENTER key                    | Enter               |
| The PAUSE key                    | Pause               |
| The CAPS LOCK key                | CapsLock            |
| The ESC key                      | Escape              |
| The SPACEBAR key                 | Space               |
| The PAGE UP key                  | PageUp              |
| The PAGE DOWN key                | PageDown            |
| The END key                      | End                 |
| The HOME key                     | Home                |
| The LEFT ARROW key               | Left                |
| The UP ARROW key                 | Up                  |
| The RIGHT ARROW key              | Right               |
| The DOWN ARROW key               | Down                |
| The PRINT SCREEN key             | PrintScreen         |
| The INS key                      | Insert              |
| The DEL key                      | Delete              |
| The left Windows logo key        | LWin                |
| The right Windows logo key       | RWin                |
| The 0 key on the numeric keypad  | NumPad0             |
| The 1 key on the numeric keypad  | NumPad1             |
| The 2 key on the numeric keypad  | NumPad2             |
| The 3 key on the numeric keypad  | NumPad3             |
| The 4 key on the numeric keypad  | NumPad4             |
| The 5 key on the numeric keypad  | NumPad5             |
| The 6 key on the numeric keypad  | NumPad6             |
| The 7 key on the numeric keypad  | NumPad7             |
| The 8 key on the numeric keypad  | NumPad8             |
| The 9 key on the numeric keypad  | NumPad9             |
| The Multiply key                 | Multiply            |
| The Add key                      | Add                 |
| The Separator key                | Separator           |
| The Subtract key                 | Subtract            |
| The Decimal key                  | Decimal             |
| The Divide key                   | Divide              |
| The NUM LOCK key                 | NumLock             |
| The SCROLL LOCK key              | Scroll              |
| The OEM angle bracket or backslash key on the RT 102 key keyboard    | OemBackslash     |
| The OEM close bracket key on a US standard keyboard                  | OemCloseBrackets |
| The OEM comma key on any country/region keyboard                     | Oemcomma         |
| The OEM minus key on any country/region keyboard                     | OemMinus         |
| The OEM open bracket key on a US standard keyboard                   | OemOpenBrackets  |
| The OEM period key on any country/egion keyboard                     | OemPeriod        |
| The OEM pipe key on a US standard keyboard                           | OemPipe          |
| The OEM plus key on any country/region keyboard                      | Oemplus          |
| The OEM question mark key on a US standard keyboard                  | OemQuestion      |
| The OEM singled/double quote key on a US standard keyboard           | OemQuotes        |
| The OEM Semicolon key on a US standard keyboard                      | OemSemicolon     |
| The OEM tilde key on a US standard keyboard                          | Oemtilde         |
