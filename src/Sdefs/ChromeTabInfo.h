#import <Foundation/Foundation.h>

@interface ChromeTabInfo: NSObject {
    @public
        NSObject* _icon;
        NSString* _title;
}

@property (retain, nonatomic) NSObject* icon;
@property (retain, nonatomic) NSString* title;

@end
