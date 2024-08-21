# LangFSExporter
Simple tool for extracting names of the game objects for the further translation `LangFS.ini` file. Based on ini parser from [Rampastring.Tools](https://github.com/Rampastring/Rampastring.Tools/releases).
## System requirements
* .NET Framework 4.8 (supports Win 7 and newer)

## How to use
There a severals way to use executable:
1. Drop `LangFSExporter.exe` to the game folder with `Rules.ini` and launch it
2. Launch `LangFSExporter.exe` with file path to the `Rules.ini`
3. Launch `LangFSExporter.exe` with direct paths to `Rules.ini` and `LangFS.ini`

Useful arguments:

| Argument | Description |
|----------|-------------|
| `/?`, `/h`, `/help`, `-h`, `--help` | Shows information about executable and how to use it |
| `-i`, `--input` | Explicit input file name. The next argument must be `Rules.ini` |
| `-o`, `--output` | Explicit input file name. The next argument must be `LangFS.ini` |

Examples of using:
```batch
LangFSExporter.exe /?
LangFSExporter.exe --help
LangFSExporter.exe Rules.ini
LangFSExporter.exe Rules.ini LangFS.ini
LangFSExporter.exe -i Rules.ini -o LangFS.ini
```
