
all: lib

lib: libchrome-scripting.a

libchrome-scripting.a: ChromeScripting.o
	ar rcs $@ $<
	ranlib $@

ChromeScripting.o: ChromeScripting.m
	clang -O2 -Wno-ignored-attributes -fobjc-arc -c $< -o $@

Chrome.m: Chrome.h ChromeScripting.h

clean:
	-@rm -rf libchrome-scripting.a ChromeScripting.o

