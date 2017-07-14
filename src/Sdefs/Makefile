CC=clang
AR=ar
RL=ranlib
RM=rm
SDEF=sdef
SDP=sdp
BM=mono ../../tools/MonoMac/bmac.exe
BM_BL=../../tools/MonoMac/MonoMac.dll
SHARPIE=/usr/local/bin/sharpie

CFLAGS=-O2 -m32 -Wno-ignored-attributes -ObjC

all: bindings

bindings: dylib lib ChromeScriptingBindings.dll

ChromeScriptingBindings.dll: ChromeScriptingBindings.cs
	sed -i '' '/\[Verify/d' $<
	$(BM) -d=MONOMAC -r=System.Drawing.dll --baselib=$(BM_BL) ChromeScriptingBindings.cs

ChromeScriptingBindings.cs: ChromeScripting.h ChromeScripting.m
	$(SHARPIE) -tlm-do-not-submit \
		bind --sdk=macosx10.12 --namespace=Actionix.Bindings --classic \
		ChromeScripting.h \
		--clang $(CFLAGS)
	@mv ApiDefinitions.cs $@

dylib: libchrome-scripting.dylib

libchrome-scripting.dylib: ChromeScripting.o
	$(CC) $(CFLAGS) -dynamiclib $< -o $@ -framework ScriptingBridge -framework Foundation

lib: libchrome-scripting.a

libchrome-scripting.a: ChromeScripting.o
	$(AR) rcs $@ $<
	$(RL) $@

ChromeScripting.o: ChromeScripting.m
	$(CC) $(CFLAGS) -c $< -o $@

ChromeScripting.m: Chrome.h ChromeScripting.h

Chrome.h: Chrome.sdef
	$(SDP) -fh --basename Chrome Chrome.sdef

Chrome.sdef:
	$(SDEF) /Applications/Google\ Chrome.app > Chrome.sdef

clean:
	-@$(RM) -rf *.o *.a *.dylib *.dll Chrome.h Chrome.sdef ChromeScriptingBindings.cs ApiDefinitions.cs
