
.PHONY: all ok fail

CXX = g++
CXXFLAGS = -std=c++11

sources = main.cpp foo.cpp
headers = foo.hpp

all: ok fail

ok: joined.cpp
	$(CXX) $(CXXFLAGS) joined.cpp

fail: $(sources)
	$(CXX) $(CXXFLAGS) $^

joined.cpp: $(sources)
	sh join.sh > joined.cpp

clean:
	rm -f a.out joined.cpp

