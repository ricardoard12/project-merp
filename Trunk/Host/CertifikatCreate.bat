makecert.exe -sr LocalMachine -ss MY -a sha1 -n CN=SimiPro2 -sky exchange -pe
certmgr.exe -add -r LocalMachine -s My -c -n SimiPro2 -r CurrentUser -s TrustedPeople