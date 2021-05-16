import React from 'react';

type NewTabHyperLinkProps = {
  label: string;
  href: string;
  className?: string;
};

/**
 * Renders an anchor tag that opens in a new tab
 * @returns 
 */
export default function NewTabHyperLink({ label, href, className }: NewTabHyperLinkProps): JSX.Element {
  return <a className={className} rel="noreferrer" target="_blank" href={href}> {label}</a>;
}
