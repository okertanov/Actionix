CC=clang
AR=ar
RL=ranlib
BM=mono ../../tools/MonoMac/bmac.exe
BM_BL=../../tools/MonoMac/MonoMac.dll

CFLAGS=-O2 -m32 -Wno-ignored-attributes -ObjC

all: bindings

bindings: dylib lib
	$(BM) -d=MONOMAC -r=System.Drawing.dll --baselib=$(BM_BL) ChromeScriptingBindings.cs

dylib: libchrome-scripting.dylib

libchrome-scripting.dylib: ChromeScripting.o
	$(CC) $(CFLAGS) -dynamiclib $< -o $@ -framework ScriptingBridge -framework Foundation

lib: libchrome-scripting.a

libchrome-scripting.a: ChromeScripting.o
	$(AR) rcs $@ $<
	$(RL) $@

ChromeScripting.o: ChromeScripting.m
	$(CC) $(CFLAGS) -c $< -o $@

Chrome.m: Chrome.h ChromeScripting.h

clean:
	-@rm -rf libchrome-scripting.a ChromeScripting.o

