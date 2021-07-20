Para executar a aplicação deve inserir os seguintes parâmetros de entrada:

"[FolderToZip]" "[FinalZipName]" "[ExtensionToExclude]" "[DirectoriesToExclude]" "[FileNameToExclude]" [TypeOfOutput] "[Parameters]"

[FolderToZip] - Pasta que pretende zippar;
[FinalZipName] - Nome final do ficheiro zippado;
[ExtensionToExclude] - Extensões que pretende excluir do zip. Pode inserir várias separadas por virgula (.txt,.png);
[DirectoriesToExclude] - Nome do directório que não pretende zippar. Exemplo: "Folder1";
[FileNameToExclude] - Nome do ficheiro que pretende excluir do zip. Exemplo: "File2";
[TypeOfOutput] - 1 -> Email, 2 -> FileShare, 3 -> Local Folder;
[Parameters] - Exemplos:
				Parametro para tipo 1: "email@email.pt"
				Parametro para tipo 2: "\\192.168.3.6\Backup\zipped.zip"
				Parametro para tipo 3: "C:\FinalFolder\"