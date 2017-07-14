#import "ChromeTabInfo.h"

@implementation ChromeTabInfo

@synthesize icon = _icon;
@synthesize title = _title;

-(instancetype)initWithTitle:(NSString*)title {
    self = [super init];

    if (self) {
        self.title = [[NSString alloc] initWithString:title];
    }

    return self;
}

@end
