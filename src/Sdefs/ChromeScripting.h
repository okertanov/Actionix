#import <Foundation/Foundation.h>
#import <ScriptingBridge/ScriptingBridge.h>

@interface ChromeScripting : NSObject

-(id)initWithBundleName:(NSString*)bundleName;

-(SBObject*)activeWindow;
-(SBObject*)activeTab;

-(NSArray<NSString*>*)allTabs;

-(void)activate;
-(void)openTab:(NSString*)url;

@end
