import { PipeTransform, Pipe } from '@angular/core';

@Pipe({ 
  name: 'highlight'
})
export class HighlightPipe implements PipeTransform {
  transform(wholeText: string, searchQuery: string): string {
    console.log('HighlightPipe')
    if (!searchQuery) {
      return wholeText;
    }
    const re = new RegExp(searchQuery, 'gi');
    return wholeText.replace(re, '<mark>$&</mark>');
  }
}